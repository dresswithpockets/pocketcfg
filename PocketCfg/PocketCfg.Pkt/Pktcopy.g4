grammar Pkt;

directiveBody : .*?;

argList : IDENT (COMMA IDENT)*;

directive : MACRO MACRO_IDENT argList? RPAREN NL+ directiveBody NL+ END;

value : IDENT
      | STRING_LIT
      | NUMBER
      | STRING;

command : value+;

statement : directive
          | command;

statementList : statement ((';'|NL) statement?)*;

fragment Quote : '"' | '\'';

NL : [\n\r]+;

COMMA : ',';
LPAREN : '(';
RPAREN : ')';
MACRO : '#macro';
END : '#end';
IDENT : [a-zA-Z0-9_]+;
STRING_LIT : Quote .*? Quote;
NUMBER : [+-]?([0-9]*[.])?[0-9]+;
STRING : ~[ \n\r\t]+;

WS : [ \t]+ -> channel(HIDDEN);
