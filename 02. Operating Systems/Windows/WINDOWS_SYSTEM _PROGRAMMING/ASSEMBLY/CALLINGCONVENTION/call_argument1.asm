; call_argument1.asm
.model flat
public _asm_main
.code

_asm_main:
	
	mov		edx, 2
	mov		ecx, 1
	call	_add
	ret

_add:
	mov		eax, edx ; eax = edx
	add		eax, ecx ; eax += ecx
	ret

end