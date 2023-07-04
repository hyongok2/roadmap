; asm1.asm

.model flat

public _asm_main

;.data
; 전역변수 만드는 자리.

.code   ; .text 

_asm_main:
	mov		eax, 100
	ret

end

