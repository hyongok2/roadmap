import cv2
import numpy as np

# day 1
img = cv2.imread('lena.jpg', cv2.IMREAD_UNCHANGED)
img = cv2.imread('lena.jpg', cv2.IMREAD_GRAYSCALE)
img = cv2.imread('lena.jpg', cv2.IMREAD_COLOR)

cv2.imshow('Image', img)
key = cv2.waitKey(0)

if key == 27:
    cv2.destroyAllWindows()
elif key == ord('s'):
    cv2.imwrite('lena_copy.png', img)
    cv2.destroyAllWindows()
