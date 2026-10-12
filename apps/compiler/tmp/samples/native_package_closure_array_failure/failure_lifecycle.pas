program failure_lifecycle;
{$mode objfpc}{$H+}

uses SysUtils, SpiralTypesCallable;

function ArrayRefCount(const value: Array0): PtrInt;
begin
  if Pointer(value) = nil then Exit(0);
  Result := PPtrInt(PByte(Pointer(value)) - (2 * SizeOf(PtrInt)))^;
end;

var
  external: Array0;
  closure: ClosureValue0;
  beforeCount: PtrInt;
  afterCount: PtrInt;
  raised: Boolean;
begin
  external := ArrayCreate0(1, False);
  DynamicArraySet0(external, 0, 7);
  closure := ClosureValueCreate0(external, 0);
  beforeCount := ArrayRefCount(external);
  if beforeCount < 2 then Halt(21);

  raised := False;
  try
    ClosureInvoke0(closure, 39);
  except
    on E: Exception do begin
      if E.Message <> 'package-owned managed array closure failure' then Halt(22);
      raised := True;
    end;
  end;
  if not raised then Halt(23);

  afterCount := ArrayRefCount(external);
  if afterCount <> beforeCount then Halt(24);
  SetLength(closure.v0, 0);
  if ArrayRefCount(external) <> beforeCount - 1 then Halt(25);
  if DynamicArrayGet0(external, 0) <> 7 then Halt(26);
  SetLength(external, 0);
  if external <> nil then Halt(27);
  Halt(42);
end.
