program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
function method1(v0: LongInt; v1: Single): Single; forward;
function method0(v0: LongInt; v1: Single): Single; forward;
function method1(v0: LongInt; v1: Single): Single;
var
  v2: LongInt;
  v3: Single;
  v4: Boolean;
begin
  while True do begin
      v2 := v0 - 1;
      v3 := v1 + 1.5;
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
function method0(v0: LongInt; v1: Single): Single;
var
  v2: Boolean;
begin
  v2 := v0 = 0;
  if v2 then begin
      Result := v1;
  end else begin
      Result := method1(v0, v1);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Single;
  v2: Single;
  v3: Boolean;
begin
  v0 := 4;
  v1 := 0.0;
  v2 := method0(v0, v1);
  v3 := v2 = 6.0;
  if v3 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
