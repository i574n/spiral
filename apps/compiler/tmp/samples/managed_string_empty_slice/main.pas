program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function StringSlice(const value: AnsiString; from, upto: Int64): AnsiString;
var len: Int64;
begin
  len := Length(value);
  if (from < 0) or (from > len) or (upto < from - 1) or (upto >= len) then Halt(3);
  if upto < from then Exit('');
  if ((Ord(value[from + 1]) and $C0) = $80) or ((upto + 1 < len) and ((Ord(value[upto + 2]) and $C0) = $80)) then Halt(3);
  Result := Copy(value, from + 1, upto - from + 1);
end;
function method0(v0: AnsiString): AnsiString; forward;
function method1(v0: AnsiString): AnsiString; forward;
function method2(v0: AnsiString): AnsiString; forward;
function method0(v0: AnsiString): AnsiString;
var
  v1: AnsiString;
begin
  v1 := StringSlice(v0, 2, 1);
  Result := v1;
end;
function method1(v0: AnsiString): AnsiString;
var
  v1: AnsiString;
begin
  v1 := StringSlice(v0, 5, 4);
  Result := v1;
end;
function method2(v0: AnsiString): AnsiString;
var
  v1: AnsiString;
begin
  v1 := StringSlice(v0, 0, (-1));
  Result := v1;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
  v7: AnsiString;
  v8: LongInt;
  v9: Boolean;
  v10: LongInt;
  v11: Boolean;
  v12: LongInt;
  v13: Boolean;
  v14: LongInt;
  v15: Boolean;
  v16: AnsiChar;
  v17: Boolean;
  v18: AnsiChar;
  v19: Boolean;
begin
  v0 := 'alpha';
  v1 := method0(v0);
  v2 := method1(v0);
  v3 := '';
  v4 := method2(v3);
  v5 := v1 + v2;
  v6 := v4 + 'ok';
  v7 := v5 + v6;
  v8 := LongInt(Length(v1));
  v9 := v8 = 0;
  if v9 then begin
      v10 := LongInt(Length(v2));
      v11 := v10 = 0;
      if v11 then begin
          v12 := LongInt(Length(v4));
          v13 := v12 = 0;
          if v13 then begin
              v14 := LongInt(Length(v7));
              v15 := v14 = 2;
              if v15 then begin
                  v16 := v7[0 + 1];
                  v17 := v16 = 'o';
                  if v17 then begin
                      v18 := v7[1 + 1];
                      v19 := v18 = 'k';
                      if v19 then begin
                          Result := 0;
                      end else begin
                          Result := 1;
                      end;
                  end else begin
                      Result := 2;
                  end;
              end else begin
                  Result := 3;
              end;
          end else begin
              Result := 4;
          end;
      end else begin
          Result := 5;
      end;
  end else begin
      Result := 6;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
