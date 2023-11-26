import random
from sklearn.datasets import fetch_openml
import matplotlib as mpl
import matplotlib.pyplot as plt

from PIL import Image
import numpy as np
from sklearn.linear_model import SGDClassifier


class MachineLearingSample:

    def __init__(self):
        self.mnist = fetch_openml('mnist_784', version=1, as_frame=False)
        X, y = self.mnist["data"], self.mnist["target"].astype(np.uint8)
        self.digits = X
        self.values = y
        self.sgd_clf = SGDClassifier(random_state=42)
        self.sgd_clf.fit(X, y)

    def get_image(self):
        some = random.randint(0, 70000)
        PIL_image = Image.fromarray(
            self.digits[some].reshape(28, 28)).convert('L')
        return (PIL_image, int(self.values[some]))

    def test(self):
        some = random.randint(0, 70000)
        return self.sgd_clf.predict([self.digits[some]]), int(self.values[some])

    def predict(self, data_array):
        check_value = np.array(data_array)
        val = self.sgd_clf.predict([check_value])
        return val