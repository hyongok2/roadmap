; call_argument2.asm
.model flat
public _asm_main
.code

_asm_main:
	
	push	2		; 2번째 인자
	push	1		; 1번째 인자
	call	_add	; push 돌아올 주소
				    ; jmp _add
	add		esp, 8	; esp = esp + 8

	ret

_add:
	mov		eax, dword ptr[esp+4]
	add		eax, dword ptr[esp+8]

	ret		; pop 돌아갈 주소
			; jmp 꺼낸 주소

end




