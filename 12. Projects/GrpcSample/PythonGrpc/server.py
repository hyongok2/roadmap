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


class CalculatorServicer(calculator_pb2_grpc.CalculatorServicer):
    def SquareRoot(self, request, context):
        reponse = calculator_pb2.Number()
        reponse.value = calculator.square_root(request.value)
        return reponse

    def SaySomething(self, request, context):
        reponse = calculator_pb2.MyMessage()
        reponse.SomeMessage = request.SomeMessage + " Hello!"
        list_data = []
        for i in request.DataArray:
            print(i)
            list_data.append(i)

        random.shuffle(list_data)
        print(request.DataArray)
        reponse.DataArray = bytes(list_data)
        return reponse


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
