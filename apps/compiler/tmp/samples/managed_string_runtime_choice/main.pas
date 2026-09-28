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
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
begin
  v0 := True;
  v1 := method0(v0);
  v2 := False;
  v3 := method0(v2);
  v4 := method1(v1);
  v5 := method1(v1);
  v6 := v4 + v5;
  v7 := method1(v3);
  v8 := v6 + v7;
  v9 := v8 - 14;
  Result := v9;
end;
begin
  Halt(SpiralMain);
end.
