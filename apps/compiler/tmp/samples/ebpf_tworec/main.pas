program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method1(v0: LongInt; v1: LongInt): LongInt; forward;
function method0(v0: LongInt): LongInt; forward;
function method3(v0: LongInt; v1: LongInt): LongInt; forward;
function method2(v0: LongInt): LongInt; forward;
function method1(v0: LongInt; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: Boolean;
begin
  while True do begin
      v2 := v0 - 1;
      v3 := v1 + 3;
      v4 := v2 = 0;
      if v4 then begin
          Result := v3;
          Exit;
      end else begin
          v0 := v2;
          v1 := v3;
          Continue;
      end;
  end;
end;
function method0(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: Boolean;
begin
  v1 := 0;
  v2 := v0 = 0;
  if v2 then begin
      Result := v1;
  end else begin
      Result := method1(v0, v1);
  end;
end;
function method3(v0: LongInt; v1: LongInt): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: Boolean;
begin
  while True do begin
      v2 := v0 - 1;
      v3 := v1 - 2;
      v4 := v2 = 0;
      if v4 then begin
          Result := v3;
          Exit;
      end else begin
          v0 := v2;
          v1 := v3;
          Continue;
      end;
  end;
end;
function method2(v0: LongInt): LongInt;
var
  v1: LongInt;
  v2: Boolean;
begin
  v1 := 0;
  v2 := v0 = 0;
  if v2 then begin
      Result := v1;
  end else begin
      Result := method3(v0, v1);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: Boolean;
  v5: Boolean;
  v4: Boolean;
begin
  v0 := 4;
  v1 := method0(v0);
  v2 := method2(v0);
  v3 := v1 = 12;
  if v3 then begin
      v4 := v2 = (-8);
      v5 := v4;
  end else begin
      v5 := False;
  end;
  if v5 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
