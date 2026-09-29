program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method0(v0: Boolean): AnsiString; forward;
function method1(v0: AnsiString): LongInt; forward;
function method0(v0: Boolean): AnsiString;
var
  v1: AnsiString;
  v2: AnsiString;
begin
  if v0 then begin
      v1 := 'alpha';
      Result := v1;
  end else begin
      v2 := 'beta';
      Result := v2;
  end;
end;
function method1(v0: AnsiString): LongInt;
var
  v1: LongInt;
begin
  v1 := LongInt(Length(v0));
  Result := v1;
end;
function SpiralMain: LongInt;
var
  v0: Boolean;
  v1: AnsiString;
  v2: Boolean;
  v3: AnsiString;
  v4: Boolean;
  v5: AnsiString;
  v6: Boolean;
  v7: AnsiString;
  v8: Boolean;
  v9: AnsiString;
  v10: Boolean;
  v11: AnsiString;
  v12: Boolean;
  v13: AnsiString;
  v14: LongInt;
  v15: LongInt;
  v16: LongInt;
  v17: LongInt;
  v18: LongInt;
  v19: LongInt;
begin
  v0 := False;
  v1 := method0(v0);
  v2 := True;
  v3 := method0(v2);
  v4 := True;
  v5 := method0(v4);
  v6 := False;
  v7 := method0(v6);
  v8 := False;
  v9 := method0(v8);
  v10 := True;
  v11 := method0(v10);
  v12 := False;
  v13 := method0(v12);
  v14 := method1(v11);
  v15 := method1(v11);
  v16 := v14 + v15;
  v17 := method1(v13);
  v18 := v16 + v17;
  v19 := v18 - 14;
  Result := v19;
end;
begin
  Halt(SpiralMain);
end.
