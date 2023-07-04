;sample_asm.asm

.model flat

public _add
public _main

.code

_add:
	push	ebp
	mov		ebp, esp
	sub		esp, 8
	
	mov		dword ptr[ebp-4], 0	
	mov		dword ptr[ebp-8], 0

	mov		eax, dword ptr[ebp+8]	
	add		eax, dword ptr[ebp+12]	
	mov		dword ptr[ebp-4], eax

	mov		eax, dword ptr[ebp-4]

	mov		esp, ebp
	pop		ebp
	ret



_main:
	push	ebp
	mov		ebp, esp
	;sub		esp, 4
	push	ecx

	push	2
	push	1
	call	_add
	add		esp, 8

	mov		dword ptr[ebp-4], eax
	
	;mov		eax, 0
	xor		eax, eax
	mov		esp, ebp
	pop		ebp
	ret

end