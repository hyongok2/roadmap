import numpy as np
import cv2

# img = cv2.imread('lena.jpg', cv2.IMREAD_COLOR)

# black image 만들기 (아래 List의 3은 RGB를 의미한다.)
img = np.zeros([512, 512, 3], np.uint8)

# 라인
img = cv2.line(img, (0, 0), (255, 255), (255, 0, 0), 5)

# 화살표 라인
img = cv2.arrowedLine(img, (0, 255), (255, 255), (0, 255, 0), 10)

# 사각형
img = cv2.rectangle(img, (280, 280), (360, 360), (0, 0, 255), 10)

# 마지막 변수를 -1로 하면 Fill 됨.
img = cv2.rectangle(img, (400, 400), (450, 450), (20, 100, 20), -1)

# 원형
img = cv2.circle(img, (100, 400), 60, (0, 200, 100), -1)

# 텍스트 넣기
font_face = cv2.FONT_HERSHEY_SIMPLEX
img = cv2.putText(img, 'OpenCV Wow!', (10, 400), font_face,
                  4, (134, 12, 76), 5, cv2.LINE_AA)

# rgb color picker  <- 이렇게 구글 검색하면, 색깔 정보를 가져올 수 있음.

cv2.imshow('image', img)

cv2.waitKey(0)
cv2.destroyAllWindows()
