import cv2

cap = cv2.VideoCapture(0)
fourcc = cv2.VideoWriter_fourcc(*'XVID')
out = cv2.VideoWriter('output.avi', fourcc, 20.0, (640, 480))

while cap.isOpened():
    ret, frame = cap.read()

    if ret == True:

        out.write(frame)

        gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)  # gray로 변환

        cv2.imshow('frame', gray)

        if cv2.waitKey(1) & 0xFF == ord('q'):
            break
    else:
        break

cap.release()
out.release()
cv2.destroyAllWindows()


# 1. 카메라 화면에 표시하기
# 2. 카메라 영상 파일 저장하기
