program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  THeap0 = record l0: Single; l1: AnsiString; end;
  TFun0 = class
    function Invoke(a0: LongInt): THeap0; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: THeap0; function Invoke(v1: LongInt): THeap0; override; end;
function ClosureCreate0(v0: THeap0): TFun0; forward;
function HeapCreate0(a0: Single; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function Tf_c0.Invoke(v1: LongInt): THeap0;
var
  v2: Boolean;
begin
  v2 := v1 = 0;
  Result := v0;
end;
function ClosureCreate0(v0: THeap0): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: Single;
  v1: AnsiString;
  v2: THeap0;
  v3: TFun0;
  v4: THeap0;
  v5: Single;
  v6: AnsiString;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
begin
  v0 := 1.5;
  v1 := 'hi';
  v2 := HeapCreate0(v0, v1);
  v3 := ClosureCreate0(v2);
  v4 := v3.Invoke(1);
  v5 := v4.l0;
  v6 := v4.l1;
  v7 := v5 = 1.5;
  if v7 then begin
      v8 := v6 = 'hi';
      v9 := v8;
  end else begin
      v9 := False;
  end;
  if v9 then begin
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
