; data2.asm
.model flat
public _asm_main

.data
L1  DD  100, 200, 300, 400
L2  DD  4 dup (100)	; 100, 100, 100, 100
L3  DD  4 dup (?)	

.code
_asm_main:	
	;mov	eax, L1

	mov		esi, offset L1
	mov		eax, dword ptr[esi + 8]

	ret	
end


