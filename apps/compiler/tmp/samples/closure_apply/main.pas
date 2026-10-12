program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  Tf_c0 = class(TFun0)  function Invoke(v0: LongInt): LongInt; override; end;
function ClosureCreate0: TFun0; forward;
function Tf_c0.Invoke(v0: LongInt): LongInt;
var
  v1: LongInt;
begin
  v1 := v0 + 1;
  Result := v1;
end;
function ClosureCreate0: TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; 
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: TFun0;
  v1: LongInt;
  v2: Boolean;
begin
  v0 := ClosureCreate0;
  v1 := v0.Invoke(6);
  v2 := v1 = 7;
  if v2 then begin
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
