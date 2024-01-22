import numpy as np
import cv2

# dir을 사용하면 cv2에 정의된 정보를 확인할 수 있음.
events = [i for i in dir(cv2) if 'EVENT' in i]
[print(ev) for ev in events]


def click_event(event, x, y, flags, param):
    # 좌표를 표시해 주도록 함.
    if event == cv2.EVENT_LBUTTONDOWN:
        print(x, ', ', y)
        font = cv2.FONT_HERSHEY_SIMPLEX
        strXY = str(x) + ', ' + str(y)
        cv2.putText(img, strXY, (x, y), font, 1, (255, 255, 0), 2)
        cv2.imshow('image', img)

    # 좌표의 색깔 정보을 표시해 주도록 함.
    if event == cv2.EVENT_RBUTTONDOWN:
        blue = img[y, x, 0]  # 배열은 y가 앞으로 오게 되는 구나...
        green = img[y, x, 1]
        red = img[y, x, 2]
        font = cv2.FONT_HERSHEY_SIMPLEX
        str_color = str(blue) + ', ' + str(green) + ', ' + str(red)
        cv2.putText(img, str_color, (x, y), font, 1, (0, 255, 255), 2)
        cv2.imshow('image', img)


# img = np.zeros((512, 512, 3), np.uint8) # <- 블랙 이미지
img = cv2.imread('lena.jpg', cv2.IMREAD_COLOR)
cv2.imshow('image', img)

cv2.setMouseCallback('image', click_event)

cv2.waitKey(0)
cv2.destroyAllWindows()
