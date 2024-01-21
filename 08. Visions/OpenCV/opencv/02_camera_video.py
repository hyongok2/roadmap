import cv2
import datetime

cap = cv2.VideoCapture(0)
fourcc = cv2.VideoWriter_fourcc(*'XVID')
# out = cv2.VideoWriter('output.avi', fourcc, 20.0, (640, 480))  # 파일로 저장하려는 경우

# Size 변경
cap.set(cv2.CAP_PROP_FRAME_WIDTH, 1280)
cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 720)

while cap.isOpened():
    ret, frame = cap.read()

    if ret == True:

        frame = cv2.flip(frame, 1)  # 반전  양수면 좌우 반전 0은 상하 반전 음수면 상하좌우 반전

        # Text 추가
        font = cv2.FONT_HERSHEY_SIMPLEX
        text = 'Width: ' + str(cap.get(cv2.CAP_PROP_FRAME_WIDTH)) + \
            ' Height: ' + str(cap.get(cv2.CAP_PROP_FRAME_HEIGHT))
        date_text = str(datetime.datetime.now())
        cv2.putText(frame, text, (10, 50), font, 1,
                    (0, 255, 255), 2, cv2.LINE_AA)
        cv2.putText(frame, date_text, (700, 50), font, 1,
                    (0, 255, 255), 2, cv2.LINE_AA)

        # 파일 저장
        # out.write(frame)

        # gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)  # gray로 변환 하려는 경우
        # cv2.imshow('frame', gray)

        # 화면 표시하기
        cv2.imshow('frame', frame)

        if cv2.waitKey(1) & 0xFF == ord('q'):
            break
    else:
        break

cap.release()
# out.release()
cv2.destroyAllWindows()


# 1. 카메라 화면에 표시하기
# 2. 카메라 영상 파일 저장하기
