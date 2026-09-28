program SpiralGenerated;
{$mode delphi}{$H+}
uses SysUtils, Math;
function method1(v0: LongInt): LongInt; forward;
function method0(v0: LongInt): LongInt; forward;
function method1(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: Boolean;
  tmp2: LongInt;
begin
  while True do begin
      v1 := v0 - 1;
      v2 := v1 = 0;
      if v2 then begin
          Result := 0;
          Exit;
      end else begin
          tmp2 := v1;
          v0 := tmp2;
          Continue;
      end;
  end;
end;
function method0(v0: LongInt): LongInt;
var
  v1: Boolean;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := 0;
  end else begin
      Result := method1(v0);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
begin
  v0 := 1000000;
  Result := method0(v0);
end;
begin
  Halt(SpiralMain);
end.
