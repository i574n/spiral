program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method2(v0: LongInt; v1: AnsiString): LongInt; forward;
function method1(v0: LongInt; v1: AnsiString): LongInt; forward;
function method0(v0: LongInt; v1: AnsiString): LongInt; forward;
function method2(v0: LongInt; v1: AnsiString): LongInt;
var
  v2: LongInt;
  v3: Boolean;
  v4: LongInt;
begin
  v2 := v0 - 1;
  v3 := v2 = 0;
  if v3 then begin
      v4 := LongInt(Length(v1));
      Result := v4;
  end else begin
      Result := method1(v2, v1);
  end;
end;
function method1(v0: LongInt; v1: AnsiString): LongInt;
var
  v2: LongInt;
  v3: Boolean;
begin
  v2 := v0 - 1;
  v3 := v2 = 0;
  if v3 then begin
      Result := 99;
  end else begin
      Result := method2(v2, v1);
  end;
end;
function method0(v0: LongInt; v1: AnsiString): LongInt;
var
  v2: Boolean;
  v5: LongInt;
  v3: LongInt;
  v6: LongInt;
begin
  v2 := v0 = 0;
  if v2 then begin
      v3 := LongInt(Length(v1));
      v5 := v3;
  end else begin
      v5 := method1(v0, v1);
  end;
  v6 := v5 - 2;
  Result := v6;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: Boolean;
  v5: AnsiString;
  v3: AnsiString;
  v4: AnsiString;
begin
  v0 := 1000000;
  v1 := v0 mod 2;
  v2 := v1 = 0;
  if v2 then begin
      v3 := 'ok';
      v5 := v3;
  end else begin
      v4 := 'go';
      v5 := v4;
  end;
  Result := method0(v0, v5);
end;
begin
  Halt(SpiralMain);
end.
