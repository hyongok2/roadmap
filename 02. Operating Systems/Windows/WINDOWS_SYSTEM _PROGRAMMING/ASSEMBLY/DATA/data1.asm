; data1.asm
.model flat
public _asm_main

.data
L1  DWORD   100
L2	DD		200
L3	DD		?

.code
_asm_main:	
	; L1 = 300
	mov		L1, 300
	
	; L1 = L2
	;mov	L1, L2
	mov		ebx, L2
	mov		L1, ebx

	;ebx = &L1
	mov		ebx, offset L1
	
	; *ebx = 300
	mov		dword ptr[ebx], 300
	mov		eax, dword ptr[ebx]    ; *ebx
	ret	
end


