grammar Res;

translationUnit : (NEWLINE? (DIRECTIVE | object))*;

objectList : (NEWLINE? object)*;

name : IDENT | STRING_LITERAL;

flagSpecifier : LBRACKET EXCL? FLAG RBRACKET;

object : name flagSpecifier? objectBody;

objectBody : STRING_LITERAL
           | (NEWLINE? LBRACE NEWLINE objectList NEWLINE RBRACE);

fragment Identifier : [a-zA-Z0-9_\-]+;
fragment LineEnder : [\n\r]+|EOF;

LBRACKET : '[';
RBRACKET : ']';
LBRACE : '{';
RBRACE : '}';
EXCL : '!';
COMMENT : '//' .*? LineEnder -> skip;
DIRECTIVE : '#' .*? LineEnder;
FLAG : '$' Identifier;
STRING_LITERAL : '"'.*?'"';
IDENT : Identifier;
NEWLINE : [\n\r]+;
WS : [ \t]+ -> skip;
