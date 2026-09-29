program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method2(v0: LongInt; v1: AnsiString; v2: AnsiString): AnsiString; forward;
function method1(v0: LongInt; v1: AnsiString): AnsiString; forward;
function method0: AnsiString; forward;
function method2(v0: LongInt; v1: AnsiString; v2: AnsiString): AnsiString;
var
  v3: LongInt;
  v4: AnsiString;
  v5: Boolean;
  v6: LongInt;
  v7: Boolean;
  v10: AnsiString;
  v8: AnsiString;
  v9: AnsiString;
  tmp8: LongInt;
  tmp9: AnsiString;
  tmp10: AnsiString;
begin
  while True do begin
      v3 := v0 - 1;
      v4 := v1 + v2;
      v5 := v3 = 0;
      if v5 then begin
          Result := v4;
          Exit;
      end else begin
          v6 := v3 mod 2;
          v7 := v6 = 0;
          if v7 then begin
              v8 := 'ab';
              v10 := v8;
          end else begin
              v9 := 'c';
              v10 := v9;
          end;
          tmp8 := v3;
          tmp9 := v4;
          tmp10 := v10;
          v0 := tmp8;
          v1 := tmp9;
          v2 := tmp10;
          Continue;
      end;
  end;
end;
function method1(v0: LongInt; v1: AnsiString): AnsiString;
var
  v2: LongInt;
  v3: AnsiString;
  v4: Boolean;
  v6: LongInt;
  v7: Boolean;
  v10: AnsiString;
  v8: AnsiString;
  v9: AnsiString;
begin
  v2 := v0 - 1;
  v3 := '' + v1;
  v4 := v2 = 0;
  if v4 then begin
      Result := v3;
  end else begin
      v6 := v2 mod 2;
      v7 := v6 = 0;
      if v7 then begin
          v8 := 'ab';
          v10 := v8;
      end else begin
          v9 := 'c';
          v10 := v9;
      end;
      Result := method2(v2, v3, v10);
  end;
end;
function method0: AnsiString;
var
  v0: LongInt;
  v1: Boolean;
  v2: AnsiString;
  v3: LongInt;
  v4: Boolean;
  v7: AnsiString;
  v5: AnsiString;
  v6: AnsiString;
begin
  v0 := 4;
  v1 := v0 = 0;
  if v1 then begin
      v2 := '';
      Result := v2;
  end else begin
      v3 := v0 mod 2;
      v4 := v3 = 0;
      if v4 then begin
          v5 := 'ab';
          v7 := v5;
      end else begin
          v6 := 'c';
          v7 := v6;
      end;
      Result := method1(v0, v7);
  end;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: LongInt;
  v2: Boolean;
  v3: AnsiChar;
  v4: Boolean;
  v5: AnsiChar;
  v6: Boolean;
begin
  v0 := method0;
  v1 := LongInt(Length(v0));
  v2 := v1 = 6;
  if v2 then begin
      v3 := v0[0 + 1];
      v4 := v3 = 'a';
      if v4 then begin
          v5 := v0[5 + 1];
          v6 := v5 = 'c';
          if v6 then begin
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
end;
begin
  Halt(SpiralMain);
end.
