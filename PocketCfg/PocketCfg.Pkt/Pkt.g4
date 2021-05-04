grammar Pkt;

statement : directive
          | alias
          ;

statementList : statement (STATEMENT_SEP statement)*;

item : string
     | IDENT
     | NUMBER;

itemList : item+;

string : ('"'|'\'') itemList ('"'|'\'');

IDENT : [a-zA-Z_][a-zA-Z0-9_]*;
NUMBER : [+-]?([0-9]*[.])?[0-9]+;