; call_argument3.asm
.model flat
public _asm_main
.code

_asm_main:
	
	push	2		
	push	1		
	call	_add	; push 돌아올 주소
				    ; jmp _add
	;add		esp, 8 ; 호출자 파괴	

	ret

_add:
	mov		eax, dword ptr[esp+4]
	add		eax, dword ptr[esp+8]
	ret     8   ; 호출 당한자 파괴

end




