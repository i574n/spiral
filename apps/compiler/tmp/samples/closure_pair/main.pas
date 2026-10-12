program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TTuple0 = record f0: LongInt; f1: LongInt; end;
  TFun0 = class
    function Invoke(a0: LongInt): TTuple0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0)  function Invoke(v0: LongInt): TTuple0; override; end;
function ClosureCreate0: TFun0; forward;
function TupleCreate0(f0: LongInt; f1: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function Tf_c0.Invoke(v0: LongInt): TTuple0;
var
  v1: LongInt;
begin
  v1 := v0 + 1;
  Result := TupleCreate0(v0, v1);
end;
function ClosureCreate0: TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; 
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TFun0;
  v2: LongInt;
  v3: LongInt;
  tmp4: TTuple0;
  v4: Boolean;
  v6: Boolean;
  v5: Boolean;
begin
  v0 := 3;
  v1 := ClosureCreate0;
  tmp4 := v1.Invoke(v0);
  v2 := tmp4.f0;
  v3 := tmp4.f1;
  v4 := v2 = 3;
  if v4 then begin
      v5 := v3 = 4;
      v6 := v5;
  end else begin
      v6 := False;
  end;
  if v6 then begin
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
