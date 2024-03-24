import cv2
import numpy as np

# day 1
#img = cv2.imread('lena.jpg', cv2.IMREAD_UNCHANGED)
#img = cv2.imread('lena.jpg', cv2.IMREAD_GRAYSCALE)
#img = cv2.imread('lena.jpg', cv2.IMREAD_COLOR)

#cv2.imshow('Image', img)
#key = cv2.waitKey(0)

#if key == 27:
#    cv2.destroyAllWindows()
#elif key == ord('s'):
#    cv2.imwrite('lena_copy.png', img)
#    cv2.destroyAllWindows()

image1 = cv2.imread('lena.jpg', cv2.IMREAD_COLOR)
image2 = cv2.imread('messi5.jpg', cv2.IMREAD_COLOR)

image1 = cv2.resize(image1, (image2.shape[1], image2.shape[0]))
num_frames = 300

transition_frames = []

# 이미지 전환을 생성합니다.
for i in range(num_frames + 1):
    # 연산으로 가중치를 계산합니다.
    weight = i / num_frames
    # 가중 평균을 사용하여 이미지를 결합합니다.
    transition = cv2.addWeighted(image1, 1 - weight, image2, weight, 0)
    transition_frames.append(transition)

# 전환된 이미지를 동영상으로 출력합니다.
for frame in transition_frames:
    cv2.imshow('Transition', frame)
    cv2.waitKey(50)  # 재생 속도 조절 (단위: ms)

cv2.destroyAllWindows()