; asm2.asm

.model flat

public _asm_main

_DATA SEGMENT
; �������� ����� �ڸ�.
_DATA ENDS

_TEXT SEGMENT

_asm_main proc
	mov		eax, 100
	ret
_asm_main endp

_TEXT ends

end