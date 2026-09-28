program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method1(v0: LongInt): Boolean; forward;
function method0(v0: LongInt): Boolean; forward;
function method1(v0: LongInt): Boolean;
var
  v1: Boolean;
begin
  v1 := v0 = 42;
  Result := v1;
end;
function method0(v0: LongInt): Boolean;
begin
  Result := method1(v0);
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
begin
  v0 := 42;
  v1 := method0(v0);
  if v1 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
begin
  Halt(SpiralMain);
end.
