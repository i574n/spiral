program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function label_1(v0: Boolean): AnsiString; forward;
function grow_0(v0: LongInt; v1: AnsiString): AnsiString; forward;
function label_1(v0: Boolean): AnsiString;
var
  v1: AnsiString;
  v2: AnsiString;
begin
  if v0 then begin
      v1 := 'a';
      Result := v1;
  end else begin
      v2 := 'b';
      Result := v2;
  end;
end;
function grow_0(v0: LongInt; v1: AnsiString): AnsiString;
var
  v2: Boolean;
  v3: LongInt;
  v4: Boolean;
  v5: AnsiString;
  v6: AnsiString;
  v7: AnsiString;
  v8: AnsiString;
  v9: AnsiString;
  v10: LongInt;
begin
  while True do begin
      v2 := v0 <= 0;
      if v2 then begin
          Result := v1;
          Exit;
      end else begin
          v3 := v0 mod 2;
          v4 := v3 = 0;
          v5 := label_1(v4);
          v6 := v1 + v5;
          v7 := v6 + '-';
          v8 := v5 + v5;
          v9 := v7 + v8;
          v10 := v0 - 1;
          v0 := v10;
          v1 := v9;
          Continue;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: LongInt;
  v6: Boolean;
  v7: AnsiChar;
  v8: Boolean;
  v9: AnsiChar;
  v10: Boolean;
  v11: AnsiChar;
  v12: Boolean;
begin
  v0 := 3;
  v1 := 's';
  v2 := grow_0(v0, v1);
  v3 := v2 + v2;
  v4 := v3 + '!';
  v5 := LongInt(Length(v4));
  v6 := v5 = 27;
  if v6 then begin
      v7 := v4[26 + 1];
      v8 := v7 = '!';
      if v8 then begin
          v9 := v4[13 + 1];
          v10 := v9 = 's';
          if v10 then begin
              v11 := v4[12 + 1];
              v12 := v11 = 'b';
              if v12 then begin
                  Result := 0;
              end else begin
                  Result := 4;
              end;
          end else begin
              Result := 3;
          end;
      end else begin
          Result := 2;
      end;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
