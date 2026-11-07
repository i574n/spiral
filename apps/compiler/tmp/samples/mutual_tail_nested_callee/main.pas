program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function count_odd_1(v0: LongInt; v1: LongInt): LongInt; forward;
function bump_2(v0: LongInt): LongInt; forward;
function count_even_0(v0: LongInt; v1: LongInt): LongInt; forward;
function count_odd_1(v0: LongInt; v1: LongInt): LongInt;
var
  v2: Boolean;
  v3: LongInt;
begin
  v2 := v0 = 0;
  if v2 then begin
      Result := v1;
  end else begin
      v3 := v0 - 1;
      Result := count_even_0(v3, v1);
  end;
end;
function bump_2(v0: LongInt): LongInt;
var
  v1: Boolean;
  v2: LongInt;
  v3: LongInt;
begin
  v1 := v0 = 4;
  if v1 then begin
      v2 := 0;
      v3 := 1;
      Result := count_odd_1(v2, v3);
  end else begin
      Result := 0;
  end;
end;
function count_even_0(v0: LongInt; v1: LongInt): LongInt;
var
  v2: Boolean;
  v3: LongInt;
  v4: LongInt;
  v5: LongInt;
begin
  v2 := v0 = 0;
  if v2 then begin
      Result := v1;
  end else begin
      v3 := v0 - 1;
      v4 := bump_2(v0);
      v5 := v1 + v4;
      Result := count_odd_1(v3, v5);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v0 := 10;
  v1 := 0;
  v2 := count_even_0(v0, v1);
  v3 := v2 - 1;
  Result := v3;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
