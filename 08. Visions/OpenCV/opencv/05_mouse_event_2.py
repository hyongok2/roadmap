import numpy as np
import cv2

# dir을 사용하면 cv2에 정의된 정보를 확인할 수 있음.
events = [i for i in dir(cv2) if 'EVENT' in i]
[print(ev) for ev in events]


def click_event(event, x, y, flags, param):

    if event == cv2.EVENT_MOUSEMOVE:

        if down[0]:
            # cv2.circle(img, (x, y), 3, (0, 0, 255), -1)
            points.append((x, y))
            if len(points) >= 2:
                cv2.line(img, points[-1], points[-2], (255, 0, 0), 5)
            cv2.imshow('image', img)

    if event == cv2.EVENT_LBUTTONDOWN:
        down[0] = True

    if event == cv2.EVENT_LBUTTONUP:
        down[0] = False
        points.clear()

    if event == cv2.EVENT_RBUTTONDOWN:
        blue = img[y, x, 0]
        green = img[y, x, 1]
        red = img[y, x, 2]
        # cv2.circle(img, (x, y), 3, (0, 0, 255), -1)
        mycolorimage = np.zeros((512, 512, 3), np.uint8)
        mycolorimage[:] = [blue, green, red]
        cv2.imshow('image2', mycolorimage)


down = [False]
# img = np.zeros((512, 512, 3), np.uint8) # <- 블랙 이미지
img = cv2.imread('lena.jpg', cv2.IMREAD_COLOR)
cv2.imshow('image', img)
points = []
cv2.setMouseCallback('image', click_event)

cv2.waitKey(0)
cv2.destroyAllWindows()
