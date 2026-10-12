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
  Tf_c0 = class(TFun0) v0: AnsiString; v1: AnsiString; function Invoke(v2: LongInt): TTuple0; override; end;
function ClosureCreate0(v0: AnsiString; v1: AnsiString): TFun0; forward;
function TupleCreate0(f0: AnsiString; f1: AnsiString): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function Tf_c0.Invoke(v2: LongInt): TTuple0;
var
  v3: Boolean;
  v4: AnsiString;
  v5: AnsiString;
begin
  v3 := v2 = 0;
  if v3 then begin
      v4 := 'no';
      v5 := 'nay';
      Result := TupleCreate0(v4, v5);
  end else begin
      Result := TupleCreate0(v0, v1);
  end;
end;
function ClosureCreate0(v0: AnsiString; v1: AnsiString): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0; c.v1 := v1;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: AnsiString;
  v2: TFun0;
  v3: AnsiString;
  v4: AnsiString;
  tmp5: TTuple0;
  v5: Boolean;
  v7: Boolean;
  v6: Boolean;
begin
  v0 := 'hi';
  v1 := 'yo';
  v2 := ClosureCreate0(v0, v1);
  tmp5 := v2.Invoke(1);
  v3 := tmp5.f0;
  v4 := tmp5.f1;
  v5 := v3 = 'hi';
  if v5 then begin
      v6 := v4 = 'yo';
      v7 := v6;
  end else begin
      v7 := False;
  end;
  if v7 then begin
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
