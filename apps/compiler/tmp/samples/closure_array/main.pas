program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TArray0 = array of LongInt;
  TFun0 = class
    function Invoke(a0: LongInt): TArray0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): TArray0; override; end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function Tf_c0.Invoke(v1: LongInt): TArray0;
var
  v2: TArray0;
  tmp1: TArray0;
begin
  tmp1 := nil;
  SetLength(tmp1, 1);
  v2 := tmp1;
  v2[0] := v0;
  Result := v2;
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TFun0;
  v2: TArray0;
  v3: LongInt;
  v4: Boolean;
begin
  v0 := 7;
  v1 := ClosureCreate0(v0);
  v2 := v1.Invoke(1);
  v3 := v2[0];
  v4 := v3 = 7;
  if v4 then begin
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
