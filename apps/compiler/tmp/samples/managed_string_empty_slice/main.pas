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
  v8: AnsiString;
  v9: AnsiString;
  v10: AnsiString;
  v11: LongInt;
  v12: Boolean;
  v13: LongInt;
  v14: Boolean;
  v15: LongInt;
  v16: Boolean;
  v17: LongInt;
  v18: Boolean;
  v19: AnsiChar;
  v20: Boolean;
  v21: AnsiChar;
  v22: Boolean;
begin
  v0 := 'alpha';
  v1 := method0(v0);
  v2 := method0(v0);
  v3 := method0(v0);
  v4 := method0(v0);
  v5 := method1(v0);
  v6 := '';
  v7 := method2(v6);
  v8 := v4 + v5;
  v9 := v7 + 'ok';
  v10 := v8 + v9;
  v11 := LongInt(Length(v4));
  v12 := v11 = 0;
  if v12 then begin
      v13 := LongInt(Length(v5));
      v14 := v13 = 0;
      if v14 then begin
          v15 := LongInt(Length(v7));
          v16 := v15 = 0;
          if v16 then begin
              v17 := LongInt(Length(v10));
              v18 := v17 = 2;
              if v18 then begin
                  v19 := v10[0 + 1];
                  v20 := v19 = 'o';
                  if v20 then begin
                      v21 := v10[1 + 1];
                      v22 := v21 = 'k';
                      if v22 then begin
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
begin
  Halt(SpiralMain);
end.
