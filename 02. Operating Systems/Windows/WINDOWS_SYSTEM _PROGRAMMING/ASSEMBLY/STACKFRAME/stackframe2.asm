; stackframe2.asm
.model flat
public _asm_main
.code

_asm_main:
	push	2
	push	1
	call	_add
	add		esp, 8
	ret

_add:
	push    ebp
	mov		ebp, esp
	
	; 지역변수 생성.  int x, y
	sub		esp, 8

	mov		dword ptr[ebp-4], 100
	mov		dword ptr[ebp-8], 200
	
	; push 100

	mov		eax, dword ptr[ebp+8]
	add		eax, dword ptr[ebp+12]

	;add		esp, 8
	mov		esp, ebp	; 지역변수 파괴
	pop		ebp
	ret
end



