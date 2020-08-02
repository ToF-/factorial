\ given N, how many trailing zeroes in N! ?
\ i.e how many multiplication 2*5 in N
\ = N/5 + N/25 + N/125 + ...  
: Z ( N -- m )
    0 SWAP 1         \ m,N,d
    BEGIN   
        5 *          \ 
        OVER OVER /  \ m,N,d,q
        >R ROT R@ +  \ N,d,m'
        -ROT R> 0=   \ m,N,d,f 
    UNTIL DROP DROP ;

\ read a number on stdin, assume no exception
: READ-INT ( -- addr,l )
    PAD DUP 40 STDIN READ-LINE THROW DROP 
    S>NUMBER? DROP DROP ;

: MAIN
    READ-INT 0 DO 
        READ-INT Z . CR 
    LOOP ;

MAIN BYE
