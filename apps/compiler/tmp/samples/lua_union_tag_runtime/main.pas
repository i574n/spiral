program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt;  end;
function US0_Northward: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Eastward: TUS0;
begin
  Result.tag := 1; 
end;
function US0_Southward: TUS0;
begin
  Result.tag := 2; 
end;
function US0_Westward: TUS0;
begin
  Result.tag := 3; 
end;
function SpiralMain: LongInt;
var
  v0: TUS0;
  v1: LongInt;
  v2: Boolean;
begin
  v0 := US0_Southward;
  v1 := v0.tag;
  v2 := v1 = 2;
  if v2 then begin
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
