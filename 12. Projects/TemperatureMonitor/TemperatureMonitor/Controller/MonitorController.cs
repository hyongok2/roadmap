using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using TemperatureMonitor.Modbus;
using TemperatureMonitor.Device;
using TemperatureMonitor.Communications;
using System.Collections.Concurrent;

namespace TemperatureMonitor.Controller
{
    public abstract class MonitorController
    {
        #region Event 정의
        public event Action<TemperatureDevice>? OnTemperatureDeviceValueChanged;
        #endregion

        #region 속성
        public TemperatureDevice? Device { get; }
        #endregion

        #region Member 변수 정의
        private readonly SerialCommunication? _serialCommunication;

        private readonly ConcurrentQueue<RequestDataSet> _requestQueue = new();
        protected readonly List<RequestDataSet> _requestList = new();
        private readonly List<byte> _responseMessage = new();
        private RequestDataSet? _currentRequestDataSet;
        private readonly ManualResetEvent _resetEvent = new(false);
        private readonly Thread _receiveDataHandleThread;
        private DateTime _requestTime = DateTime.Now;
        #endregion

        #region 생성자
        public MonitorController(string portName, int baudRate, TemperatureDevice temperatureDevice)
        {
            _serialCommunication = new SerialCommunication(portName, baudRate, dataBit: 8, Parity.None, StopBits.One);// 본 설비에서는 databit 등의 옵션은 고정이므로 여기에 하드코드 함.
            _serialCommunication.OnDataReceived += SerialCommunication_DataReceived;
            Device = temperatureDevice;
            Device.OnValueChanged += Device_OnValueChanged;

            InitialModbusDataSet();

            _receiveDataHandleThread = new Thread(ReceivedDataHandle)
            {
                IsBackground = true
            };
        }

        #endregion

        #region Public Method

        public bool Start()
        {
            if (_serialCommunication!.OpenPort() == false) return false;

            try
            {
                RequestToDevice();

                if (_receiveDataHandleThread.ThreadState != ThreadState.Running)
                    _receiveDataHandleThread.Start();
            }
            catch (Exception) // 로깅은 나중에..
            {
                _serialCommunication!.ClosePort();
                return false;
            }

            return true;
        }

        public void Stop()
        {
            try
            {
                _serialCommunication!.ClosePort();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> WriteAndVerifyAsync(ModbusData data, short value)
        {
            if (data.IsWriteData == false) return Task.FromResult(false);

            var tcs = new TaskCompletionSource<bool>();

            // 쓰기 요청 구성
            var writeRequest = new RequestDataSet(data, Device!.SlaveId, value)
            {
                CompletionSource = tcs
            };

            // 큐에 등록
            _requestQueue.Enqueue(writeRequest);

            return tcs.Task;
        }
        #endregion

        #region Private Method

        #region 이벤트 핸들러
        private void Device_OnValueChanged()
        {
            OnTemperatureDeviceValueChanged?.Invoke(Device!);
        }

        private void SerialCommunication_DataReceived(byte[] receivedData)
        {
            _responseMessage.AddRange(receivedData);
            _resetEvent.Set();
        }
        #endregion

        #region 정보 초기화 처리
        protected abstract void InitialModbusDataSet();

        #endregion

        #region 정보 읽기 요청

        private void RequestToDevice()
        {
            if (_serialCommunication!.IsOpened() == false) return;

            // 큐가 비어 있으면 요청 리스트 다시 채움
            if (_requestQueue.IsEmpty)
            {
                foreach (var request in _requestList) _requestQueue.Enqueue(request);
            }

            // 요청 꺼내기 (Thread-safe 방식)
            if (!_requestQueue.TryDequeue(out _currentRequestDataSet)) return; // 이론상 거의 없지만 이중확인

            _responseMessage.Clear(); // 응답 버퍼 초기화

            _serialCommunication.SendMessage(_currentRequestDataSet.RequestMessage.Message); // 요청 전송

            _requestTime = DateTime.Now; // 전송 시점 기록
        }

        #endregion

        #region 접수 받은 정보 처리
        private void ReceivedDataHandle(object? obj)
        {
            while (true)
            {
                _resetEvent.WaitOne(1000);
                _resetEvent.Reset();

                if (HandleTimeout()) continue;
                if (_currentRequestDataSet!.IsWriteData && HandleWriteResponse()) continue;
                if (HandleReadResponse()) continue;
            }
        }

        private bool HandleTimeout()
        {
            if (DateTime.Now - _requestTime > TimeSpan.FromSeconds(3))
            {
                _currentRequestDataSet?.CompletionSource?.TrySetResult(false);
                RequestToDevice();
                return true;
            }

            return false;
        }

        private bool HandleWriteResponse()
        {
            if (_responseMessage.Count < 8)
                return true;

            var receivedBytes = _responseMessage.ToArray();

            if (_currentRequestDataSet!.RequestMessage.Message.Take(6).SequenceEqual(receivedBytes.Take(6)))
            {
                _currentRequestDataSet.CompletionSource?.TrySetResult(true);
            }
            else
            {
                _currentRequestDataSet.CompletionSource?.TrySetResult(false);
            }

            RequestToDevice();
            return true;
        }

        private bool HandleReadResponse()
        {
            if (_responseMessage.Count < 3) return true;

            int expectedDataSize = _responseMessage[2] + 5;
            if (_responseMessage.Count < expectedDataSize) return false;
            if (_responseMessage.Count > expectedDataSize)
            {
                RequestToDevice();
                return true;
            }

            var receivedBytes = _responseMessage.ToArray();

            if (_currentRequestDataSet!.ReceivedBytes.SequenceEqual(receivedBytes))
            {
                RequestToDevice();
                return true;
            }

            var receiveMessage = new ReceiveMessage(receivedBytes);
            if (!receiveMessage.IsValid || receiveMessage.DataCount < _currentRequestDataSet.DataSize)
            {
                RequestToDevice();
                return true;
            }

            _currentRequestDataSet.ReceivedBytes = receivedBytes;

            for (int i = 0; i < _currentRequestDataSet.DataList!.Count; i++)
            {
                _currentRequestDataSet.DataList[i].Value = receiveMessage.DataArray[i];
            }

            RequestToDevice();
            return true;
        }

        #endregion

        #endregion
    }
}
