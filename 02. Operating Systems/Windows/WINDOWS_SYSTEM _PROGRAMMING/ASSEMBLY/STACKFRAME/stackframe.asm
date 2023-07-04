; stackframe.asm
.model flat
public _asm_main
.code

_asm_main:
	; _add(1,2)
	push	2
	push	1
	call	_add
	add		esp, 8
	ret

_add:
	push    ebp
	mov		ebp, esp

	;push	100
	mov		eax, dword ptr[ebp+8]
	add		eax, dword ptr[ebp+12]

	pop		ebp
	ret
end



