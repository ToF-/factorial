

\ number of multiplications by C in M
\ e.g for 100 and 5
\ result = 100/5 + 100/25 + 100/125 .. = 24

: NB-MULT ( N,C -- m )
    >R                 \ N          | C
    0 SWAP 1           \ 0,N,1      | C
    BEGIN
        R@ *           \ 0,N,d      | C
        OVER OVER      \ m,N,d,N,d  | C
        /              \ m,N,d,q    | C
        >R             \ m,N,d      | C,q
        ROT R@ +       \ N,d,m'     | C,q 
        -ROT R>        \ m,N,d,q    | C
    0= UNTIL           \ m,N,d      | C
    R> DROP            \ m,N,d    
    DROP DROP ;        \ m

\ number of trailing zeros in a factorial
\ this number is the number of times a 
\ multiple of 5 is multiplied with a 
\ multiple of 2
\ e.g for 100
\ nb of multiplications by 5 = 100/5 + 100/25 + 100/125 ... = 24
\ nb of multiplications by 2 = 100/2 + 100/4  + 100/8   ... = 97
\ nb of times 2 is multiplied by 5 = 24

: Z ( N -- Z )
    DUP  5 NB-MULT 
    SWAP 2 NB-MULT
    MIN ;

\ read a line on stdin, assume no exception
: READLN ( -- addr,l )
    PAD DUP 40 
    STDIN READ-LINE THROW
    DROP ;

: MAIN
    READLN EVALUATE
    0 DO
        READLN EVALUATE
         Z . CR
    LOOP ;

MAIN
BYE
