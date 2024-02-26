import cv2 as cv
import numpy as np


def nothing(x):
    print(x)


img = np.zeros((300, 512, 3), np.uint8)
cv.namedWindow('image')
cv.createTrackbar('B', 'image', 0, 255, nothing)
cv.createTrackbar('G', 'image', 0, 255, nothing)
cv.createTrackbar('R', 'image', 0, 255, nothing)

while True:

    b = cv.getTrackbarPos('B', 'image')
    g = cv.getTrackbarPos('G', 'image')
    r = cv.getTrackbarPos('R', 'image')

    img[:150] = [b, g, r]

    cv.imshow('image', img)
    k = cv.waitKey(1) & 0xFF
    if k == 27:
        break

cv.destroyAllWindows()
