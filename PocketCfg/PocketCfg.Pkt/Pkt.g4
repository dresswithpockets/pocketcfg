grammar Pkt;

value : STRING_LIT
      | IDENT
      | NUMBER;

statement : value+;

statementList : statement ((';'|NL) statement?)*;

fragment Quote : '"' | '\'';

STRING_LIT : Quote [^"']* Quote;
IDENT : [a-zA-Z_][a-zA-Z0-9_]*;
NUMBER : [+-]?([0-9]*[.])?[0-9]+;
NL : [\n\r]+;
WS : [ \t]+ -> channel(HIDDEN);
