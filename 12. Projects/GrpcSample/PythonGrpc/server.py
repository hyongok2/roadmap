# pip install grpcio
# pip install grpcio-tools
# python -m grpc_tools.protoc -I. --python_out=. --grpc_python_out=. calculator.proto
import grpc
from concurrent import futures
import time

import calculator_pb2
import calculator_pb2_grpc

import number_image_pb2
import number_image_pb2_grpc

import calculator
import random

from PIL import Image
import io

from machinelearning import MachineLearingNumberImage

machinelearning = MachineLearingNumberImage()


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

        # image, reponse.Value = machinelearning.get_image()
        # image.save(img_byte_arr, format='PNG')
        # reponse.DataArray = img_byte_arr.getbuffer().tobytes()
        reponse.Value = machinelearning.predict(list_data)[0]
        return reponse

# for _ in range(10):
#    return_value, real_value = machinelearning.test()
#    print(return_value, " - ", real_value)


class MachineLearningServicer(number_image_pb2_grpc.MachineLearningServicer):
    def GetRandomNumberImage(self, request, context):
        reponse = number_image_pb2.NumberImage()
        image, value = machinelearning.get_image(request.Value)
        img_byte_arr = io.BytesIO()
        image.save(img_byte_arr, format='PNG')
        reponse.DataArray = img_byte_arr.getbuffer().tobytes()
        reponse.Value = value
        return reponse

    def PredictNumberImage(self, request, context):
        list_data = []
        for i in request.DataArray:
            list_data.append(i)
        reponse = number_image_pb2.IntNumber()
        reponse.Value = machinelearning.predict(list_data)[0]
        return reponse


server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))

calculator_pb2_grpc.add_CalculatorServicer_to_server(
    CalculatorServicer(), server)

number_image_pb2_grpc.add_MachineLearningServicer_to_server(
    MachineLearningServicer(), server)

print('Starting server. Listening on port 50051')
server.add_insecure_port('[::]:50051')
server.start()

try:
    while True:
        time.sleep(86400)
except KeyboardInterrupt:
    server.stop(0)
