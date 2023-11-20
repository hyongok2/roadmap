import grpc

import calculator_pb2
import calculator_pb2_grpc

channel = grpc.insecure_channel('127.0.0.1:50051')

number = calculator_pb2.Number(value=625)

stub = calculator_pb2_grpc.CalculatorStub(channel)

reponse = stub.SquareRoot(number)

print(float(reponse.value))
