# pip install grpcio
# pip install grpcio-tools
# python -m grpc_tools.protoc -I. --python_out=. --grpc_python_out=. calculator.proto
import grpc
from concurrent import futures
import time

import calculator_pb2
import calculator_pb2_grpc

import calculator
import random

from PIL import Image
import io

from machinelearing import MachineLearingSample

sample = MachineLearingSample()


class CalculatorServicer(calculator_pb2_grpc.CalculatorServicer):
    def SquareRoot(self, request, context):
        reponse = calculator_pb2.Number()
        reponse.value = calculator.square_root(request.value)
        return reponse

    def SaySomething(self, request, context):
        reponse = calculator_pb2.MyMessage()
        reponse.SomeMessage = request.SomeMessage + " Hello!"
        list_data = []
        count = 1
        for i in request.DataArray:
            # print(i)
            list_data.append(i)

        # random.shuffle(list_data)
        # img_byte_arr = io.BytesIO()
        # image = Image.open(io.BytesIO(request.DataArray))
        # new_image = image.resize((300, 400))
        # new_image.save(img_byte_arr, format='PNG')
        # image.save(img_byte_arr, format='PNG')
        # reponse.DataArray = bytes(list_data)
        # reponse.DataArray = img_byte_arr.getbuffer().tobytes()

        # image, reponse.Value = sample.get_image()
        # image.save(img_byte_arr, format='PNG')
        # reponse.DataArray = img_byte_arr.getbuffer().tobytes()
        reponse.Value = sample.predict(list_data)[0]
        return reponse


# plt.imshow(some_digit_image,cmap="binary")
# plt.axis("off")
# plt.show()

# for _ in range(10):
#    return_value, real_value = sample.test()
#    print(return_value, " - ", real_value)

server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))

calculator_pb2_grpc.add_CalculatorServicer_to_server(
    CalculatorServicer(), server)

print('Starting server. Listening on port 50051')
server.add_insecure_port('[::]:50051')
server.start()

try:
    while True:
        time.sleep(86400)
except KeyboardInterrupt:
    server.stop(0)
