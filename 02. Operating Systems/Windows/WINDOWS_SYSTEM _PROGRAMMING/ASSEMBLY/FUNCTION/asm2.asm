; asm1.asm
.model flat

public _asm_main

_DATA SEGMENT
L1   DD  1000
_DATA ENDS


_TEXT SEGMENT

_asm_main PROC
	mov		ebx, offset L1	
	mov		dword ptr[ebx], 200
	mov		eax, [ebx]
	ret	
_asm_main ENDP


_add:
	mov		eax, 300
	ret

	;pop		ebx
	;jmp		ebx
_TEXT ENDS

end


