; call_argument2.asm
.model flat
public _asm_main
.code

_asm_main:
	
	push	2		; 2��° ����
	push	1		; 1��° ����
	call	_add	; push ���ƿ� �ּ�
				    ; jmp _add
	add		esp, 8	; esp = esp + 8

	ret

_add:
	mov		eax, dword ptr[esp+4]
	add		eax, dword ptr[esp+8]

	ret		; pop ���ư� �ּ�
			; jmp ���� �ּ�

end




