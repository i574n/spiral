program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TTuple0 = record f0: AnsiString; f1: AnsiString; end;
  TFun0 = class
    function Invoke(a0: LongInt): TTuple0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: AnsiString; function Invoke(v1: LongInt): TTuple0; override; end;
function ClosureCreate0(v0: AnsiString): TFun0; forward;
function TupleCreate0(f0: AnsiString; f1: AnsiString): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function Tf_c0.Invoke(v1: LongInt): TTuple0;
var
  v2: Boolean;
  v3: AnsiString;
  v4: AnsiString;
begin
  v2 := v1 = 0;
  if v2 then begin
      v3 := 'no';
      Result := TupleCreate0(v3, v3);
  end else begin
      v4 := 'yo';
      Result := TupleCreate0(v0, v4);
  end;
end;
function ClosureCreate0(v0: AnsiString): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: TFun0;
  v2: AnsiString;
  v3: AnsiString;
  tmp4: TTuple0;
  v4: Boolean;
  v6: Boolean;
  v5: Boolean;
begin
  v0 := 'hi';
  v1 := ClosureCreate0(v0);
  tmp4 := v1.Invoke(1);
  v2 := tmp4.f0;
  v3 := tmp4.f1;
  v4 := v2 = 'hi';
  if v4 then begin
      v5 := v3 = 'yo';
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
