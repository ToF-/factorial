

: NB-MULT  ( N,C -- m )
    2>R                 \ keep N and C on return stack
    0 1 BEGIN           \ accumulator, divisor on stack
       2R@              \ get a copy of N and C
       ROT * DUP        \ m, N, dC, dC
       -ROT /           \ m, dC, N/dC
       ROT OVER +       \ dC, N/dC, m+N/dC
       -ROT             \ m+N/dC, dC, N/dC
    0= UNTIL            \ new acc and new divison on stack
    DROP 2R> 2DROP ;    \ get rid of all except result

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
