; asm1.asm
.model flat

public _asm_main

.code

_asm_main:	
	mov		eax, 100

	;  �ٸ� �Լ� ȣ��
	;mov	ebx, POS_A
	;push	POS_A
	;jmp		_add
;POS_A:
 
	call	_add

	ret	


_add:
	mov		eax, 300
	ret

	;pop		ebx
	;jmp		ebx


end


