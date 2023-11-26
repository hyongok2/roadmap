import random
from sklearn.datasets import fetch_openml
import matplotlib as mpl
import matplotlib.pyplot as plt

from PIL import Image
import numpy as np


class MachineLearingSample:

    def __init__(self):
        self.mnist = fetch_openml('mnist_784', version=1, as_frame=False)
        X, y = self.mnist["data"], self.mnist["target"]
        self.digits = X
        self.values = y

    def get_image(self):
        some = random.randint(0, 70000)
        PIL_image = Image.fromarray(
            self.digits[some].reshape(28, 28)).convert('L')
        return (PIL_image, int(self.values[some]))
