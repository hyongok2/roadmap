; call_c.asm
.model flat
public _asm_main

extern _f1: proc
extern _f2@8: proc
extern @f3@8: proc
extern @f4@16: proc

extern _printf: proc
extern _MessageBoxA@16: proc

.data
S1 DB "hello", 10, 0  ; '/n'

.code
_asm_main:

	; MessageBoxA(0, "Hello", "Hello", MB_OK)
	push	0
	push	offset S1
	push	offset S1
	push	0
	call	_MessageBoxA@16


	; printf("hello") => __cdecl
	push	offset S1
	call	_printf
	add		esp, 4


	; f4(1,2,3,4)
	push	4
	push	3
	mov		edx, 2
	mov		ecx, 1
	call	@f4@16


	; f3(1,2)
	mov		edx, 2
	mov		ecx, 1
	call	@f3@8


	; f2(1,2)
	push	2
	push	1
	call	_f2@8


	; f1(1,2)
	push	2
	push	1
	call	_f1
	add		esp, 8


	ret
end


