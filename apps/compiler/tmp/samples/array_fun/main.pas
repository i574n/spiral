program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TFun0 = class;
  TBoxArray0 = class;
  TFun0 = class(TSpiralRc)
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
  TBoxArray0 = class(TSpiralRc) items: array of TFun0; procedure DropFields; override; end;
procedure TSpiralRc.DropFields;
begin
end;
procedure SpiralRetain(o: TSpiralRc);
begin
  if o <> nil then Inc(o.refc);
end;
procedure SpiralRelease(o: TSpiralRc);
begin
  if o <> nil then begin Dec(o.refc); if o.refc < 0 then begin o.DropFields; o.Free; end; end;
end;
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
function Tf_c0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v1 + v0;
  Result := v2;
  SpiralRelease(Self);
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
procedure TBoxArray0.DropFields;
var i: Int64;
begin
  for i := 0 to High(items) do begin SpiralRelease(items[i]); end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TFun0;
  v2: LongInt;
  v3: TBoxArray0;
  tmp4: TBoxArray0;
  v4: TFun0;
  v5: LongInt;
  v6: Boolean;
begin
  v0 := 3;
  v1 := ClosureCreate0(v0);
  v2 := 1;
  tmp4 := TBoxArray0.Create;
  SetLength(tmp4.items, v2);
  v3 := tmp4;
  SpiralRetain(v1); SpiralRelease(v3.items[0]); v3.items[0] := v1;
  SpiralRelease(v1);
  v4 := v3.items[0];
  SpiralRetain(v4);
  SpiralRetain(v4);
  SpiralRelease(v3);
  v5 := v4.Invoke(4);
  SpiralRelease(v4);
  v6 := v5 = 7;
  if v6 then begin
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
