; call_argument3.asm
.model flat
public _asm_main
.code

_asm_main:
	
	push	2		
	push	1		
	call	_add	; push ���ƿ� �ּ�
				    ; jmp _add
	;add		esp, 8 ; ȣ���� �ı�	

	ret

_add:
	mov		eax, dword ptr[esp+4]
	add		eax, dword ptr[esp+8]
	ret     8   ; ȣ�� ������ �ı�

end




